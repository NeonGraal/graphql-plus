//HintName: test_constraint-alt+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Output;

public interface ItestCnstAltOutp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltOutpObject<TType>? As_CnstAltOutp { get; }
}

public interface ItestCnstAltOutpObject<TType>
  : IGqlpInterfaceBase
{
}
