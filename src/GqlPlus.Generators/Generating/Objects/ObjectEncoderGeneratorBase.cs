using GqlPlus.Ast;

namespace GqlPlus.Generating.Objects;

internal abstract class ObjectEncoderGeneratorBase<TField>
  : GenerateForObject<TField>
  where TField : IAstObjField
{
  protected override void Generate(IAstObject<TField> ast, GqlpGeneratorContext context)
    => GenerateEncoderBlock(ast, context);

  protected void GenerateEncoderBlock(IAstObject<TField> ast, GqlpGeneratorContext context)
  {
    string typeName = context.TypeName(ast, "");
    string encoderInterface = context.TypeName(ast, "I") + "Object" + TypeParamsString(ast);
    string typePrefix = context.ModelOptions.TypePrefix;

    string? parentEncoderType = null;
    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      parentEncoderType = context.TypeName(ast.Parent, "I") + "Object" + TypeArgsString(ast.Parent.Args, context);
    }

    Dictionary<string, string> encoderFields = [];
    List<string> fieldCalls = [];

    string? parentVarName = null;
    if (parentEncoderType is not null) {
      parentVarName = GetOrAddEncoder(encoderFields, parentEncoderType, typePrefix);
    }

    foreach (TField field in ast.ObjFields) {
      AddEncoderFieldCall(field, encoderFields, fieldCalls, typePrefix, context);
    }

    WriteEncoderClass(ast, context, typeName, encoderInterface, encoderFields, fieldCalls, parentVarName);
  }

  private void AddEncoderFieldCall(TField field, Dictionary<string, string> encoderFields, List<string> fieldCalls, string typePrefix, GqlpGeneratorContext context)
  {
    bool hasDictMod = field.Modifiers.Any(m => m.ModifierKind is ModifierKind.Dictionary or ModifierKind.Param);
    if (hasDictMod) {
      return;
    }

    string fieldKey = field.Name;
    string fieldAccess = GetFieldAccess(field);
    bool hasListMod = field.Modifiers.Any(m => m.ModifierKind == ModifierKind.List);
    (string csBaseType, bool isPrimitive, bool isEnum) = ResolveFieldTypeInfo(field, context);

    string call;
    if (isPrimitive || isEnum) {
      bool hasOptionalMod = field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional;
      call = BuildPrimitiveFieldCall(fieldKey, fieldAccess, isEnum, hasListMod, hasOptionalMod);
    } else if (hasListMod) {
      call = BuildFieldListCall(field, fieldKey, fieldAccess, encoderFields, typePrefix, context);
    } else {
      call = BuildFieldCall(field, fieldKey, fieldAccess, encoderFields, typePrefix, context);
    }

    fieldCalls.Add(call);
  }

  private static string GetFieldAccess(TField field)
  {
    string fieldPropName = field.Name.Capitalize() ?? field.Name;
    return field is IAstOutputField outField && outField.Parameter is not null
      ? $"input.{fieldPropName}()"
      : $"input.{fieldPropName}";
  }

  private bool ResolveFieldTypeName(TField field, GqlpGeneratorContext context, out string fieldTypeName)
  {
    fieldTypeName = field.Type.Name;
    bool isTypeParam = field.Type.IsTypeParam;

    if (isTypeParam && context.GetArg(fieldTypeName, out IAstObjType resolvedArg) && !resolvedArg.IsTypeParam) {
      fieldTypeName = resolvedArg.Name;
      return false;
    }

    return isTypeParam;
  }

  private (string CsBaseType, bool IsPrimitive, bool IsEnum) ResolveFieldTypeInfo(TField field, GqlpGeneratorContext context)
  {
    if (ResolveFieldTypeName(field, context, out string fieldTypeName)) {
      return ("T" + fieldTypeName.Capitalize(), false, false);
    }

    string csBaseType = context.TypeName(fieldTypeName, "");
    bool isPrimitive = IsPrimitive(csBaseType);
    bool isEnum = !isPrimitive && context.GetTypeAst(fieldTypeName, out IAstEnum _);
    return (csBaseType, isPrimitive, isEnum);
  }

  private bool IsPrimitive(string csBaseType)
    => csBaseType is "string" or "bool" or "decimal";

  private string BuildPrimitiveFieldCall(string fieldKey, string fieldAccess, bool isEnum, bool hasList, bool hasOptional)
  {
    string result = string.Empty;

    if (hasOptional) {
      result = $".AddIf({fieldAccess} is not null, onTrue: t => t";
      fieldAccess += "!";
    }

    if (hasList) {
      result += $".Add(\"{fieldKey}\", {fieldAccess}.Encode())";
    } else if (isEnum) {
      result += $".AddEnum(\"{fieldKey}\", {fieldAccess})";
    } else {
      result += $".Add(\"{fieldKey}\", {fieldAccess}.Encode())";
    }

    return hasOptional ? result + ")" : result;
  }

  private string BuildFieldListCall(TField field, string fieldKey, string fieldAccess, Dictionary<string, string> encoderFields, string typePrefix, GqlpGeneratorContext context)
  {
    string encoderType = TypeString(field.Type, context, "I");
    string varName = GetOrAddEncoder(encoderFields, encoderType, typePrefix);
    string listAccess = fieldAccess.EndsWith("(null)", StringComparison.Ordinal)
      ? $"{fieldAccess} ?? []"
      : fieldAccess;
    return $".AddList(\"{fieldKey}\", {listAccess}, {varName})";
  }

  private string BuildFieldCall(TField field, string fieldKey, string fieldAccess, Dictionary<string, string> encoderFields, string typePrefix, GqlpGeneratorContext context)
  {
    string encoderType2 = TypeString(field.Type, context, "I");
    string varName2 = GetOrAddEncoder(encoderFields, encoderType2, typePrefix);
    return $".AddEncoded(\"{fieldKey}\", {fieldAccess}, {varName2})";
  }

  private static void WriteEncoderClass(IAstObject<TField> ast, GqlpGeneratorContext context, string typeName, string encoderInterface, Dictionary<string, string> encoderFields, List<string> fieldCalls, string? parentVarName)
  {
    bool needsEncoders = encoderFields.Count > 0;
    string typeParams = TypeParamsString(ast);

    context.Write("");
    WriteEncoderDeclaration(context, typeName, typeParams, encoderInterface, needsEncoders);
    context.Write("{");
    WriteEncoderFields(context, encoderFields);
    WriteEncodeMethod(context, encoderInterface, fieldCalls, parentVarName);
    WriteEncoderFactory(context, typeName, typeParams, needsEncoders);
    context.Write("}");
    RegisterEncoder(ast, context, typeName, typeParams, needsEncoders);
  }

  private static void WriteEncoderDeclaration(GqlpGeneratorContext context, string typeName, string typeParams, string encoderInterface, bool needsEncoders)
  {
    if (!needsEncoders) {
      context.Write($"internal class {typeName}Encoder{typeParams} : IEncoder<{encoderInterface}>");
      return;
    }

    context.Write($"internal class {typeName}Encoder{typeParams}(");
    context.Write("  IEncoderRepository encoders");
    context.Write($") : IEncoder<{encoderInterface}>");
  }

  private static void WriteEncoderFields(GqlpGeneratorContext context, Dictionary<string, string> encoderFields)
  {
    foreach (KeyValuePair<string, string> kv in encoderFields) {
      context.Write($"  private readonly IEncoder<{kv.Key}> {kv.Value} = encoders.EncoderFor<{kv.Key}>();");
    }
  }

  private static void WriteEncodeMethod(GqlpGeneratorContext context, string encoderInterface, List<string> fieldCalls, string? parentVarName)
  {
    List<string> encodeParts = [GetStartEncodeExpression(parentVarName), .. fieldCalls];

    context.Write($"  public Structured Encode({encoderInterface} input)");
    WriteEncodeExpression(context, encodeParts);
  }

  private static string GetStartEncodeExpression(string? parentVarName)
    => parentVarName is not null
      ? $"{parentVarName}.Encode(input)"
      : "Structured.Empty()";

  private static void WriteEncodeExpression(GqlpGeneratorContext context, List<string> encodeParts)
  {
    if (encodeParts.Count == 1) {
      context.Write($"    => {encodeParts[0]};");
      return;
    }

    context.Write($"    => {encodeParts[0]}");
    foreach (string encodePart in encodeParts.Skip(1).Take(encodeParts.Count - 2)) {
      context.Write($"      {encodePart}");
    }

    context.Write($"      {encodeParts[encodeParts.Count - 1]};");
  }

  private static void WriteEncoderFactory(GqlpGeneratorContext context, string typeName, string typeParams, bool needsEncoders)
  {
    if (!string.IsNullOrEmpty(typeParams)) {
      return;
    }

    string factoryParam = needsEncoders ? "r" : "_";
    string factoryArgs = needsEncoders ? "(r)" : "()";
    context.Write("");
    context.Write($"  internal static {typeName}Encoder Factory(IEncoderRepository {factoryParam}) => new{factoryArgs};");
  }

  private static void RegisterEncoder(IAstObject<TField> ast, GqlpGeneratorContext context, string typeName, string typeParams, bool needsEncoders)
  {
    if (!string.IsNullOrEmpty(typeParams)) {
      return;
    }

    string encoderInterface = context.TypeName(ast, "I") + "Object";
    context.RegisterEncoder(encoderInterface, typeName + "Encoder", needsEncoders);
  }

  private static string GetOrAddEncoder(Dictionary<string, string> encoderFields, string encoderType, string typePrefix)
  {
    if (encoderFields.TryGetValue(encoderType, out string? existing)) {
      return existing;
    }

    string varName = GetEncoderVarName(encoderType, typePrefix);
    string baseName = varName;
    int suffix = 2;
    while (encoderFields.ContainsValue(varName)) {
      varName = baseName + suffix++;
    }

    encoderFields[encoderType] = varName;
    return varName;
  }

  private static string GetEncoderVarName(string encoderType, string typePrefix)
  {
    string name = StripGenericArgs(encoderType);
    name = StripInterfaceOrUpperPrefix(name);
    name = StripTypePrefix(name, typePrefix);
    name = name.StartsWith("_", StringComparison.Ordinal) ? name.Substring(1) : name;
    name = name.EndsWith("Object", StringComparison.Ordinal) ? name.Substring(0, name.Length - "Object".Length) : name;
    return "_" + (name.Camelize() ?? name.ToLower(System.Globalization.CultureInfo.InvariantCulture));
  }

  private static string StripGenericArgs(string name)
  {
    int genericStart = name.IndexOf('<');
    return genericStart >= 0 ? name.Substring(0, genericStart) : name;
  }

  private static string StripInterfaceOrUpperPrefix(string name)
  {
    if (name.StartsWith("I", StringComparison.Ordinal) && name.Length > 1 && char.IsUpper(name[1])) {
      return name.Substring(1);
    }

    if (name.Length > 1 && char.IsUpper(name[0]) && char.IsUpper(name[1])) {
      return name.Substring(1);
    }

    return name;
  }

  private static string StripTypePrefix(string name, string typePrefix)
  {
    string prefixWithUnderscore = typePrefix + "_";
    if (name.StartsWith(prefixWithUnderscore, StringComparison.Ordinal)) {
      return name.Substring(prefixWithUnderscore.Length);
    }

    if (name.StartsWith(typePrefix, StringComparison.Ordinal)) {
      return name.Substring(typePrefix.Length);
    }

    return name;
  }
}
