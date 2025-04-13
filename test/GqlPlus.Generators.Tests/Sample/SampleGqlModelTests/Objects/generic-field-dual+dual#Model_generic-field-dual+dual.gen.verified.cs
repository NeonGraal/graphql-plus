//HintName: Model_generic-field-dual+dual.gen.cs
// Generated from generic-field-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_dual;

public interface IDualGnrcFieldDual
{
  RefDualGnrcFieldDual < I@054/0001 AltDualGnrcFieldDual > field { get; }
}
public class DualDualGnrcFieldDual
{
  public RefDualGnrcFieldDual < I@054/0001 AltDualGnrcFieldDual > field { get; set; }
}

public interface IRefDualGnrcFieldDual
{
  $ref Asref { get; }
}
public class DualRefDualGnrcFieldDual
{
  public $ref Asref { get; set; }
}

public interface IAltDualGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
