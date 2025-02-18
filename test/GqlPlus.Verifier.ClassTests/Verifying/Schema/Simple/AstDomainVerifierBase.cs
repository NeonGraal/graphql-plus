﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierBase<TMember>
  : VerifierBase
  where TMember : class, IGqlpDomainItem
{
  internal ForM<TMember> Members { get; } = new();
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TMember> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpDomain<TMember> domain = EFor<IGqlpDomain<TMember>>();

    verifier.Verify(domain, context);

    using AssertionScope scope = new();

    Members.NotCalled();
    Errors.Should().BeNullOrEmpty();
  }

  internal virtual AstDomainVerifier<TMember> NewDomainVerifier()
    => new(Members.Intf);
}
