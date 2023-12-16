using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

internal static class BuiltIn
{
  internal static AstType[] Basic = [
    new EnumDeclAst(AstNulls.At, "Boolean") { Aliases = ["~"], Values = [new(AstNulls.At, "false"), new(AstNulls.At, "true")] },
    new ScalarDeclAst(AstNulls.At, "Number", Array.Empty<ScalarRangeAst>()) { Aliases = ["0"] },
    new ScalarDeclAst(AstNulls.At, "String", Array.Empty<ScalarRegexAst>()) { Aliases = ["*"] },
    new EnumDeclAst(AstNulls.At, "Unit") { Aliases = ["_"], Values = [new(AstNulls.At, "_")] },
  ];

  internal static AstType[] Internal = [
    new EnumDeclAst(AstNulls.At, "Void"),
    new EnumDeclAst(AstNulls.At, "Null") { Aliases = ["null"], Values = [new(AstNulls.At, "null")] },
    new InputDeclAst(AstNulls.At, "Object") { Aliases = ["%"], Alternates = [new(AstNulls.At, new(AstNulls.At, "Any")) { Modifiers = [new ModifierAst(AstNulls.At, "String", false)] }] },
    new OutputDeclAst(AstNulls.At, "Object") { Aliases = ["%"], Alternates = [new(AstNulls.At, new(AstNulls.At, "Any")) { Modifiers = [new ModifierAst(AstNulls.At, "String", false)] }] },
    new InputDeclAst(AstNulls.At, "Any"),
    new OutputDeclAst(AstNulls.At, "Any"),
  ];

  internal static Map<string> EnumValues = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };
}
