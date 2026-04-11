//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
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
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDmnOutpObject<TRef>? As_RefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IGqlpDomainString
{
}
