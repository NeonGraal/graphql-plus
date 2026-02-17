//HintName: test_constraint-dom-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp> AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; }
  ItestCnstDomEnumOutpObject AsCnstDomEnumOutp { get; }
}

public interface ItestCnstDomEnumOutpObject
{
}

public interface ItestRefCnstDomEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumOutpObject<TType> AsRefCnstDomEnumOutp { get; }
}

public interface ItestRefCnstDomEnumOutpObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumOutp
  : IGqlpDomainEnum
{
}
