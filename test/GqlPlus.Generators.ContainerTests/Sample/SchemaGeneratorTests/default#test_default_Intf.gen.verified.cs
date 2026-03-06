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
  ItestQueryObject? As_Query { get; }
}

public interface ItestQueryObject
  : IGqlpModelImplementationBase
{
}

public interface ItestMutation
  : IGqlpModelImplementationBase
{
  ItestMutationObject? As_Mutation { get; }
}

public interface ItestMutationObject
  : IGqlpModelImplementationBase
{
}

public interface ItestSubscription
  : IGqlpModelImplementationBase
{
  ItestSubscriptionObject? As_Subscription { get; }
}

public interface ItestSubscriptionObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Schema
  : IGqlpModelImplementationBase
{
  Itest_SchemaObject? As__Schema { get; }
}

public interface Itest_SchemaObject
  : IGqlpModelImplementationBase
{
}
