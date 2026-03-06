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
  ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; }
  ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; }
}

public interface ItestCnstAltDmnInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltDmnInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestDomCnstAltDmnInp
  : IGqlpDomainString
{
}
