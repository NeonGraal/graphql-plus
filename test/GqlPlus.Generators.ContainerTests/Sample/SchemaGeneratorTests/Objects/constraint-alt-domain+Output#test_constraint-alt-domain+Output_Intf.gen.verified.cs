//HintName: test_constraint-alt-domain+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public interface ItestCnstAltDmnOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp>? AsRefCnstAltDmnOutp { get; }
  ItestCnstAltDmnOutpObject? As_CnstAltDmnOutp { get; }
}

public interface ItestCnstAltDmnOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDmnOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnOutpObject<TRef>? As_RefCnstAltDmnOutp { get; }
}

public interface ItestRefCnstAltDmnOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestDomCnstAltDmnOutp
  : IGqlpDomainString
{
}
