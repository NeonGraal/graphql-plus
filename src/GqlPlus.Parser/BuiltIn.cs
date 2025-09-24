using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class BuiltIn
{
  public static IGqlpType[] Basic { get; } = [
    Enum("Boolean", ["^", "_Boolean"], "false", "true"),
    Enum("Unit", ["_", "_Unit"], "_"),

    Domain<DomainRangeAst, IGqlpDomainRange>("Number", DomainKind.Number, "0", "_Number"),
    Domain<DomainRegexAst, IGqlpDomainRegex>("String", DomainKind.String, "*", "_String"),
  ];

  private static readonly string[] s_basicMembers = ["Boolean", "Number", "String", "Unit"];
  private static readonly string[] s_internalMembers = ["Null", "Void"];
  private static readonly string[] s_simpleMembers = ["_Union", "_Domain", "_Enum"];
  private static readonly string[] s_keyMembers = ["_Basic", "_Internal", "_Simple"];

  static BuiltIn()
    => Internal = [Scalar, Value, .. InternalSimple, .. InternalObject, .. Special];

  public static IGqlpType[] Internal { get; }

  internal static IGqlpType[] InternalSimple { get; } = [
    Enum("Void", ["_Void"]),
    Enum("Null", ["null", "_Null"], "null"),
    new UnionDeclAst(AstNulls.At, "_Basic", s_basicMembers.UnionMembers()) { Aliases = ["Basic"]},
    new UnionDeclAst(AstNulls.At, "_Internal", s_internalMembers.UnionMembers()) { Aliases = ["Internal"]},
    new UnionDeclAst(AstNulls.At, "_Simple", s_simpleMembers.UnionMembers()) { Aliases = ["Simple"]},
    new UnionDeclAst(AstNulls.At, "_Key", s_keyMembers.UnionMembers()) { Aliases = ["Key"]},
  ];

  internal static IGqlpType[] InternalObject { get; } = [
    DualObj("Object", DualRef("_Map", DualArg("_Any")), ["%", "_Object"]),

    DualObj("Opt", null, [TypeParam()], DualAlt(null), DualType("Null")),
    DualObj("List", null, [TypeParam()], DualAlt("")),
    DualObj("Dict", null, [KeyParam(), TypeParam()], DualAltParam("K")),
    DualObj("Map", DualDict("String"), [TypeParam()]),
    DualObj("Array", DualDict("Number"), [TypeParam()]),
    DualObj("IfElse", DualDict("Boolean"), [TypeParam()]),
    DualObj("Set", DualDict("Unit", true), [KeyParam()]),
    DualObj("Mask", DualDict("Boolean", true), [KeyParam()]),

    DualObj("Most", null, [TypeParam()],
      DualAlt(null), DualType("_Object"), DualMost("", true), DualType("_MostList", DualArgParam("T")), DualType("_MostDictionary", DualArgParam("T"))),
    DualObj("MostList", null, [TypeParam()], DualMost("")),
    DualObj("MostDictionary", null, [TypeParam()], DualMost("Simple", true)),
  ];

  internal static IGqlpType Scalar { get; } = new SpecialTypeAst("Scalar", t => t == Scalar);
  internal static IGqlpType Value { get; } = new SpecialTypeAst("Value", t => t == Scalar || t == Value);

  internal static SpecialTypeAst[] Special { get; } = [
    new SpecialTypeAst("Any", t => true),
    new SpecialTypeAst("Domain", t => t is IGqlpDomain),
    new SpecialTypeAst("Union", t => t is IGqlpUnion),
    new SpecialTypeAst("Enum", t => t is IGqlpEnum),
    new SpecialTypeAst("Dual", t => t is IGqlpDualObject),
    new SpecialTypeAst("Input", t => t is IGqlpInputObject),
    new SpecialTypeAst("Output", t => t is IGqlpOutputObject),
  ];

  internal static Map<string> EnumValues = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  private static DualDeclAst DualObj(string label, params IGqlpObjAlt[] alternates)
    => new(AstNulls.At, label) { Alternates = alternates };

  private static DualDeclAst DualObj(string label, ObjBaseAst parent, params string[] aliases)
    => new(AstNulls.At, label) { Aliases = aliases, Parent = parent };

  private static DualDeclAst DualObj(string label, ObjBaseAst? parent, TypeParamAst[] typeParams, params IGqlpObjAlt[] alternates)
    => new(AstNulls.At, "_" + label) { Parent = parent, TypeParams = typeParams, Alternates = alternates };

  //private static DualDeclAst DualObj(string label, TypeParamAst[] typeParams, ObjBaseAst parent)
  //  => new(AstNulls.At, "_" + label) { TypeParams = typeParams, Parent = parent };

  private static ObjAltAst DualType(string type, params IGqlpObjTypeArg[] args)
    => new ObjAltAst(AstNulls.At, type, "") with { Args = args };

  private static ObjAltAst DualAlt(string? type, bool typeParam = true)
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

  private static ObjAltAst DualAltParam(string param)
    => new(AstNulls.At, "T", "") {
      IsTypeParam = true,
      Modifiers = [ModifierAst.Param(AstNulls.At, param, false)]
    };

  private static ObjAltAst DualMost(string key, bool optional = false)
    => new(AstNulls.At, "_Most", "") {
      Args = [DualArgParam("T")],
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, optional)]
      }
    };

  private static ObjBaseAst DualRef(string name, params IGqlpObjTypeArg[] args)
    => new ObjBaseAst(AstNulls.At, name, "") with { Args = args };

  private static ObjTypeArgAst DualArg(string name)
    => new(AstNulls.At, name, "");

  private static ObjTypeArgAst DualArgParam(string name)
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
