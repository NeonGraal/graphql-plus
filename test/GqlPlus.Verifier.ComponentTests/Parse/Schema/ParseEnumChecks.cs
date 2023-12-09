﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseEnumChecks
  : BaseAliasedParserChecks<EnumInput, EnumDeclAst>
{
  public ParseEnumChecks(Parser<EnumDeclAst>.D parser)
    : base(parser) { }

  protected internal override EnumDeclAst AliasedFactory(EnumInput input)
    => new(AstNulls.At, input.Type) { Values = new[] { input.Value }.EnumValues(), };

  protected internal override string AliasesString(EnumInput input, string aliases)
    => input.Type + aliases + "{" + input.Value + "}";
}

public record struct EnumInput(string Type, string Value);
