﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

internal static class BuiltIn
{
  internal static AstType[] Basic = [
    new EnumDeclAst(AstNulls.At, "Boolean") { Aliases = ["^"], Members = [new(AstNulls.At, "false"), new(AstNulls.At, "true")] },
    new EnumDeclAst(AstNulls.At, "Unit") { Aliases = ["_"], Members = [new(AstNulls.At, "_")] },

    new AstScalar<ScalarMemberAst>(AstNulls.At, "Enum", ScalarKind.Enum, []),
    new AstScalar<ScalarRangeAst>(AstNulls.At, "Number", ScalarKind.Number, []) { Aliases = ["0"] },
    new AstScalar<ScalarRegexAst>(AstNulls.At, "String", ScalarKind.String, []) { Aliases = ["*"] },
  ];

  internal static AstType[] Internal = [
    new EnumDeclAst(AstNulls.At, "Void"),
    new EnumDeclAst(AstNulls.At, "Null") { Aliases = ["null"], Members = [new(AstNulls.At, "null")] },

    new AstScalar<ScalarReferenceAst>(AstNulls.At, "Simple", ScalarKind.Union, new [] {"^", "0", "*", "_", "_Scalar", "_Enum" }.ScalarReferences()),
    new AstScalar<ScalarReferenceAst>(AstNulls.At, "Internal", ScalarKind.Union, new [] {"Void", "Null" }.ScalarReferences()),

    DualObj("Opt", TypeParameters("T"), DualAlt(null), DualType("Null")),
    DualObj("List", TypeParameters("T"), DualAlt("")),
    DualObj("Dict", TypeParameters("K", "T"), DualAlt("$K")),
    DualObj("Map", TypeParameters("T"), DualDict("String")),
    DualObj("Array", TypeParameters("T"), DualDict("Number")),
    DualObj("IfElse", TypeParameters("T"), DualDict("Boolean")),
    DualObj("Set", TypeParameters("K"), DualDict("Unit", true)),
    DualObj("Mask", TypeParameters("K"), DualDict("Boolean, true")),
    DualObj("Object", [], DualRef("_Map") with { Arguments = [DualRef("Any")] }) with { Aliases = ["%", "_Object"] },
    DualObj("Most", TypeParameters("T"),
      DualAlt(null), DualType("Object"), DualMost(""), DualMost("", true), DualMost("Single"), DualMost("Single", true)),

    new SpecialTypeAst(AstNulls.At, "Any") { Aliases = ["Any"] },
    new SpecialTypeAst(AstNulls.At, "Enum"),
    new SpecialTypeAst(AstNulls.At, "Input"),
    new SpecialTypeAst(AstNulls.At, "Output"),
    new SpecialTypeAst(AstNulls.At, "Scalar"),
  ];

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

  private static AstAlternate<DualReferenceAst> DualType(string type)
    => new(AstNulls.At, DualRef(type));

  private static AstAlternate<DualReferenceAst> DualAlt(string? key)
    => new(AstNulls.At, DualParam("T")) {
      Modifiers = key switch {
        null => [],
        "" => [ModifierAst.List(AstNulls.At)],
        _ => [new(AstNulls.At, key, false)]
      }
    };

  private static AstAlternate<DualReferenceAst> DualMost(string key, bool optional = false)
    => new(AstNulls.At, DualRef("_Most") with { Arguments = [DualParam("T")] }) {
      Modifiers = key switch {
        "" => [optional ? ModifierAst.Optional(AstNulls.At) : ModifierAst.List(AstNulls.At)],
        _ => [new(AstNulls.At, key, optional)]
      }
    };

  private static DualReferenceAst DualRef(string name)
    => new(AstNulls.At, name, "");

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
