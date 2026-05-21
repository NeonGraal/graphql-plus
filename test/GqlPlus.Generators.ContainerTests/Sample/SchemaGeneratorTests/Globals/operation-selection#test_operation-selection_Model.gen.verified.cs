//HintName: test_operation-selection_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection;

public class testCatOprSlct
  : GqlpModelBase
  , ItestCatOprSlct
{
  public ItestCatOprSlctObject? As_CatOprSlct { get; set; }
}

public class testCatOprSlctObject
  : GqlpModelBase
  , ItestCatOprSlctObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSlct Address { get; set; }

  public testCatOprSlctObject
    ( string pfirst
    , string plast
    , ItestAddrOprSlct paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSlct
  : GqlpModelBase
  , ItestAddrOprSlct
{
  public ItestAddrOprSlctObject? As_AddrOprSlct { get; set; }
}

public class testAddrOprSlctObject
  : GqlpModelBase
  , ItestAddrOprSlctObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSlctObject
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
