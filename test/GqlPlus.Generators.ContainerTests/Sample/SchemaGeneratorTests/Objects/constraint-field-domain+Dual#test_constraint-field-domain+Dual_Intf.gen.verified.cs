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
  ItestCnstFieldDmnDualObject AsCnstFieldDmnDual { get; }
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>
{
}

public interface ItestRefCnstFieldDmnDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDmnDualObject<TRef> AsRefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IGqlpDomainString
{
}
