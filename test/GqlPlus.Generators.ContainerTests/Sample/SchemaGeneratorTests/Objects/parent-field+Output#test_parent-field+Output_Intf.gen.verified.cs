//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  ItestPrntFieldOutpObject AsPrntFieldOutp { get; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntFieldOutpObject AsRefPrntFieldOutp { get; }
}

public interface ItestRefPrntFieldOutpObject
{
  decimal Parent { get; }
}
