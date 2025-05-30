using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class BuiltIn
{
  public static IGqlpType[] Basic { get; } = [
    new EnumDeclAst(AstNulls.At, "Boolean", [new(AstNulls.At, "false"), new(AstNulls.At, "true")]) { Aliases = ["^"] },
    new EnumDeclAst(AstNulls.At, "Unit", [new(AstNulls.At, "_")]) { Aliases = ["_"] },

    new AstDomain<DomainLabelAst, IGqlpDomainLabel>(AstNulls.At, "Enum", DomainKind.Enum, []),
    new AstDomain<DomainRangeAst, IGqlpDomainRange>(AstNulls.At, "Number", DomainKind.Number, []) { Aliases = ["0"] },
    new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, "String", DomainKind.String, []) { Aliases = ["*"] },
  ];

  public static IGqlpType[] Internal { get; } = [
    new EnumDeclAst(AstNulls.At, "Void", []),
    new EnumDeclAst(AstNulls.At, "Null", [new(AstNulls.At, "null")]) { Aliases = ["null"] },

    new UnionDeclAst(AstNulls.At, "Simple", new[] { "Boolean", "Number", "String", "Unit", "_Union", "_Domain", "_Enum" }.UnionMembers()),
    new UnionDeclAst(AstNulls.At, "Internal", new[] { "Void", "Null" }.UnionMembers()),

    DualObj("Opt", [TypeParam()], DualAlt(null), DualType("Null")),
    DualObj("List", [TypeParam()], DualAlt("")),
    DualObj("Dict", [KeyParam(), TypeParam()], DualAltParam("K")),
    DualObj("Map", [TypeParam()], DualDict("String")),
    DualObj("Array", [TypeParam()], DualDict("Number")),
    DualObj("IfElse", [TypeParam()], DualDict("Boolean")),
    DualObj("Set", [KeyParam()], DualDict("Unit", true)),
    DualObj("Mask", [KeyParam()], DualDict("Boolean", true)),
    DualObj("Object", [], DualRef("_Map", DualArg("_Any"))) with { Aliases = ["%", "Object"] },
    DualObj("Most", [TypeParam()],
      DualAlt(null), DualType("_Object"), DualMost("", true), DualType("_MostList", DualArgParam("T")), DualType("_MostDictionary", DualArgParam("T"))),
    DualObj("MostList", [TypeParam()], DualMost("")),
    DualObj("MostDictionary", [TypeParam()], DualMost("Simple", true)),

    new SpecialTypeAst("Any") { Aliases = ["Any"] },
    new SpecialTypeAst("Dual"),
    new SpecialTypeAst("Enum"),
    new SpecialTypeAst("Input"),
    new SpecialTypeAst("Output"),
    new SpecialTypeAst("Domain"),
    new SpecialTypeAst("Union"),
  ];

  internal static Map<string> EnumValues = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  private static TypeParamAst KeyParam()
    => new(AstNulls.At, "K") { Constraint = "Simple" };
  private static TypeParamAst TypeParam(string constraint = "_Any")
    => new(AstNulls.At, "T") { Constraint = constraint };

  private static DualDeclAst DualObj(string label, TypeParamAst[] typeParams, params IGqlpDualAlternate[] alternates)
    => new(AstNulls.At, "_" + label) { TypeParams = typeParams, ObjAlternates = alternates };

  private static DualDeclAst DualObj(string label, TypeParamAst[] typeParams, DualBaseAst parent)
    => new(AstNulls.At, "_" + label) { TypeParams = typeParams, Parent = parent };

  private static DualAlternateAst DualType(string type, params IGqlpDualArg[] args)
    => new DualAlternateAst(AstNulls.At, type, "") with { BaseArgs = args };

  private static DualAlternateAst DualAlt(string? key)
    => new(AstNulls.At, "T", "") {
      IsTypeParam = true,
      Modifiers = key switch {
        null => [],
        "" => [ModifierAst.List(AstNulls.At)],
        "$K" => [ModifierAst.Param(AstNulls.At, "K", false)],
        _ => [ModifierAst.Dict(AstNulls.At, key, false)],
      }
    };

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

  private static DualBaseAst DualRefParam(string name)
    => DualRef(name) with { IsTypeParam = true };

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
}
