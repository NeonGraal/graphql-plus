//HintName: test_operation-selection-inline_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection-inline.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_inline;

public class testCatOprSlctInln
  : GqlpModelBase
  , ItestCatOprSlctInln
{
  public ItestCatOprSlctInlnObject? As_CatOprSlctInln { get; set; }
}

public class testCatOprSlctInlnObject
  : GqlpModelBase
  , ItestCatOprSlctInlnObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSlctInln Address { get; set; }

  public testCatOprSlctInlnObject
    ( string pfirst
    , string plast
    , ItestAddrOprSlctInln paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSlctInln
  : GqlpModelBase
  , ItestAddrOprSlctInln
{
  public ItestFullOprSlctInln? AsFullOprSlctInln { get; set; }
  public string? AsString { get; set; }
  public ItestAddrOprSlctInlnObject? As_AddrOprSlctInln { get; set; }
}

public class testAddrOprSlctInlnObject
  : GqlpModelBase
  , ItestAddrOprSlctInlnObject
{

  public testAddrOprSlctInlnObject
    ()
  {
  }
}

public class testFullOprSlctInln
  : GqlpModelBase
  , ItestFullOprSlctInln
{
  public ItestFullOprSlctInlnObject? As_FullOprSlctInln { get; set; }
}

public class testFullOprSlctInlnObject
  : GqlpModelBase
  , ItestFullOprSlctInlnObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testFullOprSlctInlnObject
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
