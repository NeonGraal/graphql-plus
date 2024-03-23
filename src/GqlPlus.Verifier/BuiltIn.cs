﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

internal static class BuiltIn
{
  internal static AstType[] Basic = [
    new EnumDeclAst(AstNulls.At, "Boolean") { Aliases = ["^"], Members = [new(AstNulls.At, "false"), new(AstNulls.At, "true")] },
    new EnumDeclAst(AstNulls.At, "Unit") { Aliases = ["_"], Members = [new(AstNulls.At, "_")] },

    new AstScalar<ScalarMemberAst>(AstNulls.At, "Enum", ScalarDomain.Enum, []),
    new AstScalar<ScalarRangeAst>(AstNulls.At, "Number", ScalarDomain.Number, []) { Aliases = ["0"] },
    new AstScalar<ScalarRegexAst>(AstNulls.At, "String", ScalarDomain.String, []) { Aliases = ["*"] },
  ];

  public static IEnumerable<object[]> AllBasic()
    => Basic.Select(b => new object[] { b });

  internal static AstType[] Internal = [
    new EnumDeclAst(AstNulls.At, "Void"),
    new EnumDeclAst(AstNulls.At, "Null") { Aliases = ["null"], Members = [new(AstNulls.At, "null")] },

    new UnionDeclAst(AstNulls.At, "Simple", new[] {"^", "0", "*", "_", "_Union", "_Scalar", "_Enum" }.UnionMembers()),
    new UnionDeclAst(AstNulls.At, "Internal", new[] {"Void", "Null" }.UnionMembers()),

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

    new SpecialTypeAst(AstNulls.At, "Any") { Aliases = ["Any"] },
    new SpecialTypeAst(AstNulls.At, "Dual"),
    new SpecialTypeAst(AstNulls.At, "Enum"),
    new SpecialTypeAst(AstNulls.At, "Input"),
    new SpecialTypeAst(AstNulls.At, "Output"),
    new SpecialTypeAst(AstNulls.At, "Scalar"),
    new SpecialTypeAst(AstNulls.At, "Union"),
  ];

  public static IEnumerable<object[]> AllInternal()
    => Internal.Select(b => new object[] { b });

  internal static Map<string> EnumValues = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  private static TypeParameterAst[] TypeParameters(params string[] parameters)
    => [.. parameters.Select(r => new TypeParameterAst(AstNulls.At, r))];

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, params AstAlternate<DualReferenceAst>[] alternates)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, Alternates = alternates };

  private static DualDeclAst DualObj(string label, TypeParameterAst[] typeParameters, DualReferenceAst parent)
    => new(AstNulls.At, "_" + label) { TypeParameters = typeParameters, Parent = parent };

  private static AstAlternate<DualReferenceAst> DualType(string type, params DualReferenceAst[] args)
    => new(AstNulls.At, DualRef(type, args));

  private static AstAlternate<DualReferenceAst> DualAlt(string? key)
    => new(AstNulls.At, DualParam("T")) {
      Modifiers = key switch {
        null => [],
        "" => [ModifierAst.List(AstNulls.At)],
        _ => [new(AstNulls.At, key, false)]
      }
    };

  private static AstAlternate<DualReferenceAst> DualMost(string key, bool optional = false)
    => new(AstNulls.At, DualRef("_Most", DualParam("T"))) {
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [new(AstNulls.At, key, optional)]
      }
    };

  private static DualReferenceAst DualRef(string name, params DualReferenceAst[] args)
    => new DualReferenceAst(AstNulls.At, name, "") with { Arguments = args };

  private static DualReferenceAst DualParam(string name)
    => DualRef(name) with { IsTypeParameter = true };

  private static DualReferenceAst DualDict(string type, bool paramSecond = false)
    => DualRef("_Dict") with {
      Arguments = [
        paramSecond ? DualParam("K") : DualRef(type),
        paramSecond ? DualRef(type) : DualParam("T")
      ]
    };
}
