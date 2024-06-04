﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  IVerifyAliased<IGqlpDualObject> aliased,
  IMerge<IGqlpDualField> fields,
  IMerge<IGqlpAlternate<IGqlpDualBase>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualField, IGqlpDualBase, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(IGqlpDualObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }
}
