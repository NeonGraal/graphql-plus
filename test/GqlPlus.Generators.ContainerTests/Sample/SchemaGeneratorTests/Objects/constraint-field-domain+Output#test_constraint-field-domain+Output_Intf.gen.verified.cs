//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
{
  ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>
{
}

public interface ItestRefCnstFieldDmnOutp<TRef>
{
  ItestRefCnstFieldDmnOutpObject<TRef> AsRefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IDomainString
{
}
