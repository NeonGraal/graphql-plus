using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class BuiltIn
{
  public static AstType[] Basic { get; } = [
    new EnumDeclAst(AstNulls.At, "Boolean", [new(AstNulls.At, "false"), new(AstNulls.At, "true")]) { Aliases = ["^"] },
    new EnumDeclAst(AstNulls.At, "Unit", [new(AstNulls.At, "_")]) { Aliases = ["_"] },

    new AstDomain<DomainMemberAst, IGqlpDomainMember>(AstNulls.At, "Enum", DomainKind.Enum, []),
    new AstDomain<DomainRangeAst, IGqlpDomainRange>(AstNulls.At, "Number", DomainKind.Number, []) { Aliases = ["0"] },
    new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, "String", DomainKind.String, []) { Aliases = ["*"] },
  ];

  public static IEnumerable<object[]> AllBasic()
    => Basic.Select(b => new object[] { b });

  public static AstType[] Internal { get; } = [
    new EnumDeclAst(AstNulls.At, "Void", []),
    new EnumDeclAst(AstNulls.At, "Null", [new(AstNulls.At, "null")]) { Aliases = ["null"] },

    new UnionDeclAst(AstNulls.At, "Simple", new[] { "^", "0", "*", "_", "_Union", "_Domain", "_Enum" }.UnionMembers()),
    new UnionDeclAst(AstNulls.At, "Internal", new[] { "Void", "Null" }.UnionMembers()),

    DualObj("Opt", TypeParameters("T"), DualAlt(null), DualType("Null")),
    DualObj("List", TypeParameters("T"), DualAlt("")),
    DualObj("Dict", TypeParameters("K", "T"), DualAlt("$K")),
    DualObj("Map", TypeParameters("T"), DualDict("String")),
    DualObj("Array", TypeParameters("T"), DualDict("Number")),
    DualObj("IfElse", TypeParameters("T"), DualDict("Boolean")),
    DualObj("Set", TypeParameters("K"), DualDict("Unit", true)),
    DualObj("Mask", TypeParameters("K"), DualDict("Boolean", true)),
    DualObj("Object", [], DualRef("_Map", DualRef("Any"))) with { Aliases = ["%", "Object"] },
    DualObj("Most", TypeParameters("T"),
      DualAlt(null), DualType("Object"), DualMost("", true), DualType("_MostList", DualParam("T")), DualType("_MostDictionary", DualParam("T"))),
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

  public static IEnumerable<object[]> AllInternal()
    => Internal.Select(b => new object[] { b });

  internal static Map<string> EnumValues = new()
  {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  private static TypeParameterAst[] TypeParameters(params string[] parameters)
    => [.. parameters.Select(r => new TypeParameterAst(AstNulls.At, r))];

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, params AstAlternate<IGqlpDualBase>[] alternates)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, Alternates = alternates };

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, DualBaseAst parent)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, Parent = parent };

  private static AstAlternate<IGqlpDualBase> DualType(string type, params DualBaseAst[] args)
    => new(AstNulls.At, DualRef(type, args));

  private static AstAlternate<IGqlpDualBase> DualAlt(string? key)
    => new(AstNulls.At, DualParam("T"))
    {
      Modifiers = key switch
      {
        null => [],
        "" => [ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, false)]
      }
    };

  private static AstAlternate<IGqlpDualBase> DualMost(string key, bool optional = false)
    => new(AstNulls.At, DualRef("_Most", DualParam("T")))
    {
      Modifiers = key switch
      {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [ModifierAst.Dict(AstNulls.At, key, optional)]
      }
    };

  private static DualBaseAst DualRef(string name, params DualBaseAst[] args)
    => new DualBaseAst(AstNulls.At, name, "") with { TypeArguments = args };

  private static DualBaseAst DualParam(string name)
    => DualRef(name) with { IsTypeParameter = true };

  private static DualBaseAst DualDict(string type, bool paramSecond = false)
    => DualRef("_Dict") with
    {
      TypeArguments = [
        paramSecond ? DualParam("K") : DualRef(type),
        paramSecond ? DualRef(type) : DualParam("T")
      ]
    };
}
