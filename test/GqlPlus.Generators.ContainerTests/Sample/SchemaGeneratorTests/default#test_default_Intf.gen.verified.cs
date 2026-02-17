//HintName: test_default_Intf.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

public interface ItestQuery
  : IGqlpModelImplementationBase
{
  ItestQueryObject AsQuery { get; }
}

public interface ItestQueryObject
{
}

public interface ItestMutation
  : IGqlpModelImplementationBase
{
  ItestMutationObject AsMutation { get; }
}

public interface ItestMutationObject
{
}

public interface ItestSubscription
  : IGqlpModelImplementationBase
{
  ItestSubscriptionObject AsSubscription { get; }
}

public interface ItestSubscriptionObject
{
}

public interface Itest_Schema
  : IGqlpModelImplementationBase
{
  Itest_SchemaObject As_Schema { get; }
}

public interface Itest_SchemaObject
{
}
