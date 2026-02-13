using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class BuiltIn
{
  public const string BooleanType = "Boolean";
  public const string BooleanAlias = "^";
  public const string BooleanFalse = GqlpStrings.BoolFalse;
  public const string BooleanTrue = GqlpStrings.BoolTrue;
  public const string NullType = "Null";
  public const string NullValue = "null";
  public const string NumberType = "Number";
  public const string NumberAlias = "0";
  public const string ScalarType = "Scalar";
  public const string StringType = "String";
  public const string StringAlias = "*";
  public const string UnitType = "Unit";
  public const string UnitValue = "_";
  public const string ValueType = "Value";
  public const string VoidType = "Void";

  public static IGqlpType[] Basic { get; } = [
    Enum(BooleanType, [BooleanAlias, "_" + BooleanType], BooleanFalse, BooleanTrue),
    Enum(UnitType, [UnitValue, "_" + UnitType], UnitValue),

    Domain<DomainRangeAst, IGqlpDomainRange>(NumberType, DomainKind.Number, NumberAlias, "_" + NumberType),
    Domain<DomainRegexAst, IGqlpDomainRegex>(StringType, DomainKind.String, StringAlias, "_" + StringType),
  ];

  private static readonly string[] s_basicMembers = [BooleanType, NumberType, StringType, UnitType];
  private static readonly string[] s_internalMembers = [NullType, VoidType];
  private static readonly string[] s_simpleMembers = ["_Union", "_Domain", "_Enum"];
  private static readonly string[] s_keyMembers = ["_Basic", "_Internal", "_Simple"];

  static BuiltIn()
  {
    SpecialTypeAst scalar = new(ScalarType, t => t == Scalar);
    SpecialTypeAst value = new(ValueType, t => t == Scalar || t == Value);

    Special = [
      new SpecialTypeAst("Any"),
      new SpecialTypeAst("Domain", TypeKind.Domain, t => t is IGqlpDomain),
      new SpecialTypeAst("Union", TypeKind.Union, t => t is IGqlpUnion),
      new SpecialTypeAst("Enum", TypeKind.Enum, t => t is IGqlpEnum),
      new SpecialTypeAst("Dual", TypeKind.Dual, t => t is IGqlpObject<IGqlpDualField>),
      new SpecialTypeAst("Input", TypeKind.Input, t => t is IGqlpObject<IGqlpInputField>),
      new SpecialTypeAst("Output", TypeKind.Output, t => t is IGqlpObject<IGqlpOutputField>),
      scalar, value,
    ];
    Internal = [.. InternalSimple, .. InternalObject, .. Special];
    Scalar = scalar;
    Value = value;
  }

  public static IGqlpType[] Internal { get; }

  internal static IGqlpType[] InternalSimple { get; } = [
    Enum(VoidType, ["_Void"]),
    Enum(NullType, [NullValue, "_Null"], NullValue),
    new UnionDeclAst(AstNulls.At, "_Basic", s_basicMembers.UnionMembers()) { Aliases = ["Basic"]},
    new UnionDeclAst(AstNulls.At, "_Internal", s_internalMembers.UnionMembers()) { Aliases = ["Internal"]},
    new UnionDeclAst(AstNulls.At, "_Simple", s_simpleMembers.UnionMembers()) { Aliases = ["Simple"]},
    new UnionDeclAst(AstNulls.At, "_Key", s_keyMembers.UnionMembers()) { Aliases = ["Key"]},
  ];

  internal static IGqlpType[] InternalObject { get; } = [
    DualObj("Object", DualRef("_Map", DualArg("_Any")), ["%", "_Object"]),

    DualObj("Opt", null, [TypeParam()], DualAlt(null), DualType(NullType)),
    DualObj("List", null, [TypeParam()], DualAlt("")),
    DualObj("Dict", null, [KeyParam(), TypeParam()], DualAltParam("K")),
    DualObj("Map", DualDict(StringType), [TypeParam()]),
    DualObj("Array", DualDict(NumberType), [TypeParam()]),
    DualObj("IfElse", DualDict(BooleanType), [TypeParam()]),
    DualObj("Set", DualDict(UnitType, true), [KeyParam()]),
    DualObj("Mask", DualDict(BooleanType, true), [KeyParam()]),

    DualObj("Most", null, [TypeParam()],
      DualAlt(null), DualType("_Object"), DualMost("", true), DualType("_MostList", DualArgParam("T")), DualType("_MostDictionary", DualArgParam("T"))),
    DualObj("MostList", null, [TypeParam()], DualMost("")),
    DualObj("MostDictionary", null, [TypeParam()], DualMost("Simple", true)),
  ];

  internal static IGqlpType Scalar { get; }
  internal static IGqlpType Value { get; }

  internal static IGqlpTypeSpecial[] Special { get; }

  internal static Map<string> EnumValues = new() {
    [UnitValue] = UnitType,
    [NullValue] = NullType,
    [BooleanTrue] = BooleanType,
    [BooleanFalse] = BooleanType,
  };

  private static AstObject<IGqlpDualField> DualObj(string label, ObjBaseAst parent, params string[] aliases)
    => new(TypeKind.Dual, AstNulls.At, label, "") { Aliases = aliases, Parent = parent };

  private static AstObject<IGqlpDualField> DualObj(
    string label,
    ObjBaseAst? parent,
    TypeParamAst[] typeParams,
    params IGqlpAlternate[] alternates
  ) => new(TypeKind.Dual, AstNulls.At, "_" + label, "") { Parent = parent, TypeParams = typeParams, Alternates = alternates };

  private static AlternateAst DualType(string type, params IGqlpTypeArg[] args)
    => new AlternateAst(AstNulls.At, type, "") with { Args = args };

  private static AlternateAst DualAlt(string? type, bool typeParam = true)
    => typeParam || type is null
      ? new(AstNulls.At, "T", "") {
        IsTypeParam = true,
        Modifiers = type switch {
          null => [],
          "" => [ModifierAst.List(AstNulls.At)],
          "$K" => [ModifierAst.Param(AstNulls.At, "K", false)],
          _ => [ModifierAst.Dict(AstNulls.At, type, false)],
        }
      }
      : new(AstNulls.At, type, "");

  private static AlternateAst DualAltParam(string param)
    => new(AstNulls.At, "T", "") {
      IsTypeParam = true,
      Modifiers = [ModifierAst.Param(AstNulls.At, param, false)]
    };

  private static AlternateAst DualMost(string key, bool optional = false)
    => new(AstNulls.At, "_Most", "") {
      Args = [DualArgParam("T")],
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, optional)]
      }
    };

  private static ObjBaseAst DualRef(string name, params IGqlpTypeArg[] args)
    => new ObjBaseAst(AstNulls.At, name, "") with { Args = args };

  private static TypeArgAst DualArg(string name)
    => new(AstNulls.At, name, "");

  private static TypeArgAst DualArgParam(string name)
    => DualArg(name) with { IsTypeParam = true };

  private static ObjBaseAst DualDict(string type, bool paramSecond = false)
    => DualRef("_Dict") with {
      Args = [
        paramSecond ? DualArgParam("K") : DualArg(type),
        paramSecond ? DualArg(type) : DualArgParam("T")
      ]
    };

  private static EnumDeclAst Enum(string type, string[] aliases, params string[] labels)
    => new(AstNulls.At, type, labels.EnumLabels()) { Aliases = aliases };

  private static AstDomain<TAst, TLabel> Domain<TAst, TLabel>(string type, DomainKind kind, params string[] aliases)
    where TAst : AstBase, TLabel
    where TLabel : IGqlpDomainItem, IGqlpError
    => new(AstNulls.At, type, kind, []) { Aliases = aliases };

  private static TypeParamAst KeyParam()
      => new(AstNulls.At, "K") { Constraint = "_Key" };

  private static TypeParamAst TypeParam(string constraint = "_Any")
    => new(AstNulls.At, "T") { Constraint = constraint };
}
