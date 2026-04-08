//HintName: test_constraint-alt-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public interface ItestCnstAltDmnDual
  // No Base because it's Class
{
  ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; }
  ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; }
}

public interface ItestCnstAltDmnDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDmnDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; }
}

public interface ItestRefCnstAltDmnDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestDomCnstAltDmnDual
  : IGqlpDomainString
{
}
