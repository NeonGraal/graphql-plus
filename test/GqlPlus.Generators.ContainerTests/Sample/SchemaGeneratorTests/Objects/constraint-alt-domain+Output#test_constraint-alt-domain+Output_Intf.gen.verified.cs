//HintName: test_constraint-alt-domain+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public interface ItestCnstAltDmnOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; }
  ItestCnstAltDmnOutpObject AsCnstAltDmnOutp { get; }
}

public interface ItestCnstAltDmnOutpObject
{
}

public interface ItestRefCnstAltDmnOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltDmnOutpObject<TRef> AsRefCnstAltDmnOutp { get; }
}

public interface ItestRefCnstAltDmnOutpObject<TRef>
{
}

public interface ItestDomCnstAltDmnOutp
  : IGqlpDomainString
{
}
