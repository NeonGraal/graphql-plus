//HintName: test_operation-selection-spread_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection-spread.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_spread;

public class testCatOprSlctSprd
  : GqlpModelBase
  , ItestCatOprSlctSprd
{
  public ItestCatOprSlctSprdObject? As_CatOprSlctSprd { get; set; }
}

public class testCatOprSlctSprdObject
  : GqlpModelBase
  , ItestCatOprSlctSprdObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSlctSprd Address { get; set; }

  public testCatOprSlctSprdObject
    ( string pfirst
    , string plast
    , ItestAddrOprSlctSprd paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSlctSprd
  : GqlpModelBase
  , ItestAddrOprSlctSprd
{
  public ItestAddrOprSlctSprdObject? As_AddrOprSlctSprd { get; set; }
}

public class testAddrOprSlctSprdObject
  : GqlpModelBase
  , ItestAddrOprSlctSprdObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSlctSprdObject
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
