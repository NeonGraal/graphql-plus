//HintName: test_default_Model.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

public class testQuery
  : GqlpModelImplementationBase
  , ItestQuery
{
  public ItestQueryObject? As_Query { get; set; }
}

public class testQueryObject
  : GqlpModelImplementationBase
  , ItestQueryObject
{
}

public class testMutation
  : GqlpModelImplementationBase
  , ItestMutation
{
  public ItestMutationObject? As_Mutation { get; set; }
}

public class testMutationObject
  : GqlpModelImplementationBase
  , ItestMutationObject
{
}

public class testSubscription
  : GqlpModelImplementationBase
  , ItestSubscription
{
  public ItestSubscriptionObject? As_Subscription { get; set; }
}

public class testSubscriptionObject
  : GqlpModelImplementationBase
  , ItestSubscriptionObject
{
}

public class test_Schema
  : GqlpModelImplementationBase
  , Itest_Schema
{
  public Itest_SchemaObject? As__Schema { get; set; }
}

public class test_SchemaObject
  : GqlpModelImplementationBase
  , Itest_SchemaObject
{
}
