//HintName: test_constraint-field-domain+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
{
  ItestCnstFieldDmnOutpObject? As_CnstFieldDmnOutp { get; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>
{
}

public interface ItestRefCnstFieldDmnOutp<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldDmnOutpObject<TRef>? As_RefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IGqlpDomainString
{
}
