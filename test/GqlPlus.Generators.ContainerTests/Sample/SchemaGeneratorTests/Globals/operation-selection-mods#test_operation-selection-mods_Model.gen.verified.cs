//HintName: test_operation-selection-mods_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

public class testCatOprSlctMods
  : GqlpModelBase
  , ItestCatOprSlctMods
{
  public ItestCatOprSlctModsObject? As_CatOprSlctMods { get; set; }
}

public class testCatOprSlctModsObject
  : GqlpModelBase
  , ItestCatOprSlctModsObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSlctMods Address { get; set; }

  public testCatOprSlctModsObject
    ( string pfirst
    , string plast
    , ItestAddrOprSlctMods paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSlctMods
  : GqlpModelBase
  , ItestAddrOprSlctMods
{
  public ItestAddrOprSlctModsObject? As_AddrOprSlctMods { get; set; }
}

public class testAddrOprSlctModsObject
  : GqlpModelBase
  , ItestAddrOprSlctModsObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSlctModsObject
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
