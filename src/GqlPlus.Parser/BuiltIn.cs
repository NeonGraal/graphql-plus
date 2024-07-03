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

    new AstDomain<DomainMemberAst, IGqlpDomainMember>(AstNulls.At, "Enum", DomainKind.Enum, []),
    new AstDomain<DomainRangeAst, IGqlpDomainRange>(AstNulls.At, "Number", DomainKind.Number, []) { Aliases = ["0"] },
    new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, "String", DomainKind.String, []) { Aliases = ["*"] },
  ];

  public static IGqlpType[] Internal { get; } = [
    new EnumDeclAst(AstNulls.At, "Void", []),
    new EnumDeclAst(AstNulls.At, "Null", [new(AstNulls.At, "null")]) { Aliases = ["null"] },

    new UnionDeclAst(AstNulls.At, "Simple", new[] { "^", "0", "*", "_", "_Union", "_Domain", "_Enum" }.UnionMembers()),
    new UnionDeclAst(AstNulls.At, "Internal", new[] { "Void", "Null" }.UnionMembers()),

    DualObj("Opt", TypeParameters("T"), DualAlt(null), DualType("Null")),
    DualObj("List", TypeParameters("T"), DualAlt("")),
    DualObj("Dict", TypeParameters("K", "T"), DualAltParam("K")),
    DualObj("Map", TypeParameters("T"), DualDict("String")),
    DualObj("Array", TypeParameters("T"), DualDict("Number")),
    DualObj("IfElse", TypeParameters("T"), DualDict("Boolean")),
    DualObj("Set", TypeParameters("K"), DualDict("Unit", true)),
    DualObj("Mask", TypeParameters("K"), DualDict("Boolean", true)),
    DualObj("Object", [], DualRef("_Map", DualArg("_Any"))) with { Aliases = ["%", "Object"] },
    DualObj("Most", TypeParameters("T"),
      DualAlt(null), DualType("_Object"), DualMost("", true), DualType("_MostList", DualArgParam("T")), DualType("_MostDictionary", DualArgParam("T"))),
    DualObj("MostList", TypeParameters("T"), DualMost("")),
    DualObj("MostDictionary", TypeParameters("T"), DualMost("Simple", true)),

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

  private static TypeParameterAst[] TypeParameters(params string[] parameters)
    => [.. parameters.Select(r => new TypeParameterAst(AstNulls.At, r))];

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, params IGqlpDualAlternate[] alternates)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, ObjAlternates = alternates };

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, DualBaseAst parent)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, Parent = parent };

  private static DualAlternateAst DualType(string type, params IGqlpDualArgument[] args)
    => new(AstNulls.At, DualRef(type, args));

  private static DualAlternateAst DualAlt(string? key)
    => new(AstNulls.At, DualRefParam("T")) {
      Modifiers = key switch {
        null => [],
        "" => [ModifierAst.List(AstNulls.At)],
        "$K" => [ModifierAst.Param(AstNulls.At, "K", false)],
        _ => [ModifierAst.Dict(AstNulls.At, key, false)],
      }
    };

  private static DualAlternateAst DualAltParam(string param)
    => new(AstNulls.At, DualRefParam("T")) {
      Modifiers = [ModifierAst.Param(AstNulls.At, param, false)]
    };

  private static DualAlternateAst DualMost(string key, bool optional = false)
    => new(AstNulls.At, DualRef("_Most", DualArgParam("T"))) {
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, optional)]
      }
    };

  private static DualBaseAst DualRef(string name, params IGqlpDualArgument[] args)
    => new DualBaseAst(AstNulls.At, name, "") with { BaseArguments = args };

  private static DualBaseAst DualRefParam(string name)
    => DualRef(name) with { IsTypeParameter = true };

  private static DualArgumentAst DualArg(string name)
    => new(AstNulls.At, name, "");

  private static DualArgumentAst DualArgParam(string name)
    => DualArg(name) with { IsTypeParameter = true };

  private static DualBaseAst DualDict(string type, bool paramSecond = false)
    => DualRef("_Dict") with {
      BaseArguments = [
        paramSecond ? DualArgParam("K") : DualArg(type),
        paramSecond ? DualArg(type) : DualArgParam("T")
      ]
    };
}
