//HintName: test_default_Impl.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
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

  public testQueryObject()
  {
  }
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

  public testMutationObject()
  {
  }
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

  public testSubscriptionObject()
  {
  }
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

  public test_SchemaObject()
  {
  }
}
