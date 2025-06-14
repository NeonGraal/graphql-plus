using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class BuiltIn
{
  public static IGqlpType[] Basic { get; } = [
    Enum("Boolean", "^", "false", "true"),
    Enum("Unit", "_", "_"),

    Domain<DomainLabelAst, IGqlpDomainLabel>("Enum", DomainKind.Enum),
    Domain<DomainRangeAst, IGqlpDomainRange>("Number", DomainKind.Number, "0"),
    Domain<DomainRegexAst, IGqlpDomainRegex>("String", DomainKind.String, "*"),
  ];

  private static readonly string[] s_unionMembers = ["Boolean", "Number", "String", "Unit", "_Union", "_Domain", "_Enum"];

  public static IGqlpType[] Internal { get; } = [
    Enum("Void", ""),
    Enum("Null", "null", "null"),

    new UnionDeclAst(AstNulls.At, "Simple", s_unionMembers.UnionMembers()) { Aliases = ["_Simple"]},
    DualObj("Internal", DualAlt("Void", false), DualAlt("Object", false), DualAlt("Null" , false)),
    DualObj("Object", DualRef("_Map", DualArg("_Any")), ["%", "_Object"]),

    DualObj("Opt", [TypeParam()], DualAlt(null), DualType("Null")),
    DualObj("List", [TypeParam()], DualAlt("")),
    DualObj("Dict", [KeyParam(), TypeParam()], DualAltParam("K")),
    DualObj("Map", [TypeParam()], DualDict("String")),
    DualObj("Array", [TypeParam()], DualDict("Number")),
    DualObj("IfElse", [TypeParam()], DualDict("Boolean")),
    DualObj("Set", [KeyParam()], DualDict("Unit", true)),
    DualObj("Mask", [KeyParam()], DualDict("Boolean", true)),

    DualObj("Most", [TypeParam()],
      DualAlt(null), DualType("_Object"), DualMost("", true), DualType("_MostList", DualArgParam("T")), DualType("_MostDictionary", DualArgParam("T"))),
    DualObj("MostList", [TypeParam()], DualMost("")),
    DualObj("MostDictionary", [TypeParam()], DualMost("Simple", true)),

    new SpecialTypeAst("Any", t => true) { Aliases = ["Any"] },
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

  private static DualDeclAst DualObj(string label, params IGqlpDualAlternate[] alternates)
    => new(AstNulls.At, label) { ObjAlternates = alternates };

  private static DualDeclAst DualObj(string label, DualBaseAst parent, params string[] aliases)
    => new(AstNulls.At, label) { Aliases = aliases, Parent = parent };

  private static DualDeclAst DualObj(string label, TypeParamAst[] typeParams, params IGqlpDualAlternate[] alternates)
    => new(AstNulls.At, "_" + label) { TypeParams = typeParams, ObjAlternates = alternates };

  private static DualDeclAst DualObj(string label, TypeParamAst[] typeParams, DualBaseAst parent)
    => new(AstNulls.At, "_" + label) { TypeParams = typeParams, Parent = parent };

  private static DualAlternateAst DualType(string type, params IGqlpDualArg[] args)
    => new DualAlternateAst(AstNulls.At, type, "") with { BaseArgs = args };

  private static DualAlternateAst DualAlt(string? type, bool typeParam = true)
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

  private static DualAlternateAst DualAltParam(string param)
    => new(AstNulls.At, "T", "") {
      IsTypeParam = true,
      Modifiers = [ModifierAst.Param(AstNulls.At, param, false)]
    };

  private static DualAlternateAst DualMost(string key, bool optional = false)
    => new(AstNulls.At, "_Most", "") {
      BaseArgs = [DualArgParam("T")],
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, optional)]
      }
    };

  private static DualBaseAst DualRef(string name, params IGqlpDualArg[] args)
    => new DualBaseAst(AstNulls.At, name, "") with { BaseArgs = args };

  private static DualArgAst DualArg(string name)
    => new(AstNulls.At, name, "");

  private static DualArgAst DualArgParam(string name)
    => DualArg(name) with { IsTypeParam = true };

  private static DualBaseAst DualDict(string type, bool paramSecond = false)
    => DualRef("_Dict") with {
      BaseArgs = [
        paramSecond ? DualArgParam("K") : DualArg(type),
        paramSecond ? DualArg(type) : DualArgParam("T")
      ]
    };

  private static EnumDeclAst Enum(string type, string alias, params string[] labels)
    => new(AstNulls.At, type, labels.EnumLabels()) {
      Aliases = string.IsNullOrWhiteSpace(alias) ? [] : [alias]
    };

  private static AstDomain<TAst, TLabel> Domain<TAst, TLabel>(string type, DomainKind kind, params string[] aliases)
    where TAst : AstBase, TLabel
    where TLabel : IGqlpDomainItem, IGqlpError
    => new(AstNulls.At, type, kind, []) { Aliases = aliases };

  private static TypeParamAst KeyParam()
      => new(AstNulls.At, "K") { Constraint = "Simple" };

  private static TypeParamAst TypeParam(string constraint = "_Any")
    => new(AstNulls.At, "T") { Constraint = constraint };
}
