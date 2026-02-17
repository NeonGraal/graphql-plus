//HintName: test_object-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Output;

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
  ItestObjPrntOutpObject AsObjPrntOutp { get; }
}

public interface ItestObjPrntOutpObject
  : ItestRefObjPrntOutpObject
{
}

public interface ItestRefObjPrntOutp
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; }
}

public interface ItestRefObjPrntOutpObject
{
}
