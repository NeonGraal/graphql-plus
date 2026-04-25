//HintName: test_Operation_Enc.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_OperationsEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OperationsObject>
{
  private readonly IEncoder<Itest_Operation> _itest_Operation = encoders.EncoderFor<Itest_Operation>();
  private readonly IEncoder<Itest_Type> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_OperationsObject input)
    => Structured.Empty()
      .AddEncoded("operation", input.Operation, _itest_Operation)
      .AddEncoded("type", input.Type, _itest_Type);

  internal static test_OperationsEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpDirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectivesObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpDirectivesObject input)
    => _itest_Named.Encode(input)
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpDirectivesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OperationEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OperationObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  private readonly IEncoder<Itest_OpResult> _itest_OpResult = encoders.EncoderFor<Itest_OpResult>();
  public Structured Encode(Itest_OperationObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("category", input.Category, _itest_Name)
      .AddList("directives", input.Directives, _itest_OpDirective)
      .AddEncoded("result", input.Result, _itest_OpResult);

  internal static test_OperationEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpVariableEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpVariableObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_OpVariableObject input)
    => _itest_OpDirectives.Encode(input)
      .AddEncoded("type", input.Type, _itest_TypeRef)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers)
      .AddEncoded("defaultValue", input.DefaultValue, _gqlpValue);

  internal static test_OpVariableEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpDirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectiveObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpDirectiveObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("argument", input.Argument, _itest_OpArgument);

  internal static test_OpDirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpFragmentEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFragmentObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  public Structured Encode(Itest_OpFragmentObject input)
    => _itest_OpDirectives.Encode(input)
      .AddEncoded("type", input.Type, _itest_TypeRef);

  internal static test_OpFragmentEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgumentEncoder : IEncoder<Itest_OpArgumentObject>
{
  public Structured Encode(Itest_OpArgumentObject input)
    => Structured.Empty();

  internal static test_OpArgumentEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpArgValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgValueObject>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_OpArgValueObject input)
    => Structured.Empty()
      .AddEncoded("variable", input.Variable, _itest_Name);

  internal static test_OpArgValueEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgListEncoder : IEncoder<Itest_OpArgListObject>
{
  public Structured Encode(Itest_OpArgListObject input)
    => Structured.Empty();

  internal static test_OpArgListEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpArgMapEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgMapObject>
{
  private readonly IEncoder<Itest_OpArgValue> _itest_OpArgValue = encoders.EncoderFor<Itest_OpArgValue>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_OpArgMapObject input)
    => Structured.Empty()
      .AddEncoded("value", input.Value, _itest_OpArgValue)
      .AddEncoded("byVariable", input.ByVariable, _itest_Name);

  internal static test_OpArgMapEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpResultEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpResultObject>
{
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpResultObject input)
    => Structured.Empty()
      .AddEncoded("argument", input.Argument, _itest_OpArgument);

  internal static test_OpResultEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_PathEncoder : IEncoder<Itest_Path>
{
  public Structured Encode(Itest_Path input)
    => input.Value!.Encode();

  internal static test_PathEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpSelectionEncoder : IEncoder<Itest_OpSelectionObject>
{
  public Structured Encode(Itest_OpSelectionObject input)
    => Structured.Empty();

  internal static test_OpSelectionEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFieldObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_OpFieldObject input)
    => _itest_OpDirectives.Encode(input)
      .AddIf(input.FieldAlias is not null, onTrue: t => t.Add("fieldAlias", input.FieldAlias!.Encode()))
      .AddEncoded("argument", input.Argument, _itest_OpArgument)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);

  internal static test_OpFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpInlineEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpInlineObject>
{
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpInlineObject input)
    => Structured.Empty()
      .AddEncoded("type", input.Type, _itest_TypeRef)
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpInlineEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpSpreadEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpSpreadObject>
{
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpSpreadObject input)
    => Structured.Empty()
      .Add("fragment", input.Fragment.Encode())
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpSpreadEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_OperationEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_OperationEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_OperationsObject>(test_OperationsEncoder.Factory)
      .AddEncoder<Itest_OpDirectivesObject>(test_OpDirectivesEncoder.Factory)
      .AddEncoder<Itest_OperationObject>(test_OperationEncoder.Factory)
      .AddEncoder<Itest_OpVariableObject>(test_OpVariableEncoder.Factory)
      .AddEncoder<Itest_OpDirectiveObject>(test_OpDirectiveEncoder.Factory)
      .AddEncoder<Itest_OpFragmentObject>(test_OpFragmentEncoder.Factory)
      .AddEncoder<Itest_OpArgumentObject>(test_OpArgumentEncoder.Factory)
      .AddEncoder<Itest_OpArgValueObject>(test_OpArgValueEncoder.Factory)
      .AddEncoder<Itest_OpArgListObject>(test_OpArgListEncoder.Factory)
      .AddEncoder<Itest_OpArgMapObject>(test_OpArgMapEncoder.Factory)
      .AddEncoder<Itest_OpResultObject>(test_OpResultEncoder.Factory)
      .AddEncoder<Itest_Path>(test_PathEncoder.Factory)
      .AddEncoder<Itest_OpSelectionObject>(test_OpSelectionEncoder.Factory)
      .AddEncoder<Itest_OpFieldObject>(test_OpFieldEncoder.Factory)
      .AddEncoder<Itest_OpInlineObject>(test_OpInlineEncoder.Factory)
      .AddEncoder<Itest_OpSpreadObject>(test_OpSpreadEncoder.Factory);
}
