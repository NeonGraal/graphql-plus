//HintName: test_constraint-alt-domain+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public interface ItestCnstAltDmnInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; }
  ItestCnstAltDmnInpObject AsCnstAltDmnInp { get; }
}

public interface ItestCnstAltDmnInpObject
{
}

public interface ItestRefCnstAltDmnInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltDmnInpObject<TRef> AsRefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<TRef>
{
}

public interface ItestDomCnstAltDmnInp
  : IGqlpDomainString
{
}
