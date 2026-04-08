//HintName: test_constraint-alt-domain+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public interface ItestCnstAltDmnOutp
  // No Base because it's Class
{
  ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp>? AsRefCnstAltDmnOutp { get; }
  ItestCnstAltDmnOutpObject? As_CnstAltDmnOutp { get; }
}

public interface ItestCnstAltDmnOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDmnOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnOutpObject<TRef>? As_RefCnstAltDmnOutp { get; }
}

public interface ItestRefCnstAltDmnOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestDomCnstAltDmnOutp
  : IGqlpDomainString
{
}
