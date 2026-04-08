//HintName: test_constraint-field-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
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
  // No Base because it's Class
{
  ItestRefCnstFieldDmnDualObject<TRef>? As_RefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IGqlpDomainString
{
}
