//HintName: test_default_Intf.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

public interface ItestQuery
  : IGqlpInterfaceBase
{
  ItestQueryObject? As_Query { get; }
}

public interface ItestQueryObject
  : IGqlpInterfaceBase
{
}

public interface ItestMutation
  : IGqlpInterfaceBase
{
  ItestMutationObject? As_Mutation { get; }
}

public interface ItestMutationObject
  : IGqlpInterfaceBase
{
}

public interface ItestSubscription
  : IGqlpInterfaceBase
{
  ItestSubscriptionObject? As_Subscription { get; }
}

public interface ItestSubscriptionObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Schema
  : IGqlpInterfaceBase
{
  Itest_SchemaObject? As__Schema { get; }
}

public interface Itest_SchemaObject
  : IGqlpInterfaceBase
{
}
