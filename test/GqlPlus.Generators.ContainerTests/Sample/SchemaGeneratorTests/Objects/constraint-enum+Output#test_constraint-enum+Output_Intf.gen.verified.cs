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
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; }
  ItestCnstEnumOutpObject? As_CnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumOutp
{
  cnstEnumOutp,
}
