//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp> AsEnumCnstEnumOutpcnstEnumOutp { get; }
  ItestCnstEnumOutpObject AsCnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
{
}

public interface ItestRefCnstEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumOutpObject<TType> AsRefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
{
  TType Field { get; }
}
