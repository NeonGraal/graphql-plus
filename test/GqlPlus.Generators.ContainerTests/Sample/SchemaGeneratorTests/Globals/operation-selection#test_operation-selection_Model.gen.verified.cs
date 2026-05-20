//HintName: test_operation-selection_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection;

public class testCatOprSelection
  : GqlpModelBase
  , ItestCatOprSelection
{
  public ItestCatOprSelectionObject? As_CatOprSelection { get; set; }
}

public class testCatOprSelectionObject
  : GqlpModelBase
  , ItestCatOprSelectionObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSelection Address { get; set; }

  public testCatOprSelectionObject
    ( string pfirst
    , string plast
    , ItestAddrOprSelection paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSelection
  : GqlpModelBase
  , ItestAddrOprSelection
{
  public ItestAddrOprSelectionObject? As_AddrOprSelection { get; set; }
}

public class testAddrOprSelectionObject
  : GqlpModelBase
  , ItestAddrOprSelectionObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSelectionObject
    ( string pstreet
    , string pcity
    , string pcountry
    )
  {
    Street = pstreet;
    City = pcity;
    Country = pcountry;
  }
}
