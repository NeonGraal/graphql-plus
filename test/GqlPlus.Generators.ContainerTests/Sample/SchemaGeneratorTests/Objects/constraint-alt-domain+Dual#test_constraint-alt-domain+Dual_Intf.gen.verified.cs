//HintName: test_constraint-alt-domain+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public interface ItestCnstAltDmnDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; }
  ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; }
}

public interface ItestCnstAltDmnDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDmnDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; }
}

public interface ItestRefCnstAltDmnDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestDomCnstAltDmnDual
  : IGqlpDomainString
{
}
