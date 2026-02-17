//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
{
  ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>
{
}

public interface ItestRefCnstFieldDmnOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDmnOutpObject<TRef> AsRefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IGqlpDomainString
{
}
