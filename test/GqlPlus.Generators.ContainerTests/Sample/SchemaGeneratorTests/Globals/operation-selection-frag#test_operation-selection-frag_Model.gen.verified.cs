//HintName: test_operation-selection-frag_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection-frag.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_frag;

public class testCatOprSlctFrag
  : GqlpModelBase
  , ItestCatOprSlctFrag
{
  public ItestCatOprSlctFragObject? As_CatOprSlctFrag { get; set; }
}

public class testCatOprSlctFragObject
  : GqlpModelBase
  , ItestCatOprSlctFragObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSlctFrag Address { get; set; }

  public testCatOprSlctFragObject
    ( string pfirst
    , string plast
    , ItestAddrOprSlctFrag paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSlctFrag
  : GqlpModelBase
  , ItestAddrOprSlctFrag
{
  public ItestAddrOprSlctFragObject? As_AddrOprSlctFrag { get; set; }
}

public class testAddrOprSlctFragObject
  : GqlpModelBase
  , ItestAddrOprSlctFragObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSlctFragObject
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
