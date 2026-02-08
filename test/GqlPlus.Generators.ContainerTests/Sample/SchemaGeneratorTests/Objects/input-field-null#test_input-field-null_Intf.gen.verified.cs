//HintName: test_input-field-null_Intf.gen.cs
// Generated from input-field-null.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public interface ItestInpFieldNull
{
  public ItestInpFieldNullObject AsInpFieldNull { get; set; }
}

public interface ItestInpFieldNullObject
{
  public ItestFldInpFieldNull? Field { get; set; }
}

public interface ItestFldInpFieldNull
{
  public ItestFldInpFieldNullObject AsFldInpFieldNull { get; set; }
}

public interface ItestFldInpFieldNullObject
{
}
