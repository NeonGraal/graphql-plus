﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate, IGqlpDualArg> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualBase, IGqlpDualArg, IGqlpDualField, IGqlpDualAlternate, EnumContext>(verifiers)
{
  protected override EnumContext MakeContext(IGqlpDualObject usage, IGqlpType[] aliased, IMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }
}
