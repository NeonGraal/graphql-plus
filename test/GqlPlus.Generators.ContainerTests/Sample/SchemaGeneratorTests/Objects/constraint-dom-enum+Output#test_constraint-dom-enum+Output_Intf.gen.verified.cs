//HintName: test_constraint-dom-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; }
  ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; }
}

public interface ItestCnstDomEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; }
}

public interface ItestRefCnstDomEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumOutp
{
  cnstDomEnumOutp,
  other,
}

public interface ItestJustCnstDomEnumOutp
  : IGqlpDomainEnum
{
  new testEnumCnstDomEnumOutp? Value { get; }
}
