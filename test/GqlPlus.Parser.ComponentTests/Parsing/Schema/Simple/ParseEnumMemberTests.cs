﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseEnumMemberTests(
  IBaseAliasedChecks<string, IGqlpEnumItem> checks
) : BaseAliasedTests<string, IGqlpEnumItem>(checks)
{ }

internal sealed class ParseEnumMemberChecks(
  Parser<IGqlpEnumItem>.D parser
) : BaseAliasedChecks<string, EnumMemberAst, IGqlpEnumItem>(parser)
{
  protected internal override EnumMemberAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
