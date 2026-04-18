//HintName: test_parent-field+Output_Model.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public ItestPrntFieldOutpObject? As_PrntFieldOutp { get; set; }
}

public class testPrntFieldOutpObject
  : testRefPrntFieldOutpObject
  , ItestPrntFieldOutpObject
{
  public decimal Field { get; set; }

  public testPrntFieldOutpObject
    ( decimal parent
    , decimal field
    ) : base(parent)
  {
    Field = field;
  }
}

public class testRefPrntFieldOutp
  : GqlpModelBase
  , ItestRefPrntFieldOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntFieldOutpObject? As_RefPrntFieldOutp { get; set; }
}

public class testRefPrntFieldOutpObject
  : GqlpModelBase
  , ItestRefPrntFieldOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntFieldOutpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
