//HintName: test_default_Model.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

public class testQuery
  : GqlpModelBase
  , ItestQuery
{
  public ItestQueryObject? As_Query { get; set; }
}

public class testQueryObject
  : GqlpModelBase
  , ItestQueryObject
{

  public testQueryObject
    ()
  {
  }
}

public class testMutation
  : GqlpModelBase
  , ItestMutation
{
  public ItestMutationObject? As_Mutation { get; set; }
}

public class testMutationObject
  : GqlpModelBase
  , ItestMutationObject
{

  public testMutationObject
    ()
  {
  }
}

public class testSubscription
  : GqlpModelBase
  , ItestSubscription
{
  public ItestSubscriptionObject? As_Subscription { get; set; }
}

public class testSubscriptionObject
  : GqlpModelBase
  , ItestSubscriptionObject
{

  public testSubscriptionObject
    ()
  {
  }
}

public class test_Schema
  : GqlpModelBase
  , Itest_Schema
{
  public Itest_SchemaObject? As__Schema { get; set; }
}

public class test_SchemaObject
  : GqlpModelBase
  , Itest_SchemaObject
{

  public test_SchemaObject
    ()
  {
  }
}
