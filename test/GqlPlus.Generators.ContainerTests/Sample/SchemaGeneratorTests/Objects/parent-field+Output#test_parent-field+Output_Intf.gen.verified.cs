//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  ItestPrntFieldOutpObject? As_PrntFieldOutp { get; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntFieldOutpObject? As_RefPrntFieldOutp { get; }
}

public interface ItestRefPrntFieldOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
