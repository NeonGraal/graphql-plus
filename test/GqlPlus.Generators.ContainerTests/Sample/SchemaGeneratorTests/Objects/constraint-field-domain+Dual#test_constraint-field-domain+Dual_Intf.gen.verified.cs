//HintName: test_constraint-field-domain+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
{
  ItestCnstFieldDmnDualObject? As_CnstFieldDmnDual { get; }
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>
{
}

public interface ItestRefCnstFieldDmnDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDmnDualObject<TRef>? As_RefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IGqlpDomainString
{
}
