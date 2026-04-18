//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; }
  ItestCnstEnumOutpObject? As_CnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumOutp
{
  cnstEnumOutp,
}
