//HintName: Model_generic-field-dual+output.gen.cs
// Generated from generic-field-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_output;

public interface IOutpGnrcFieldDual
{
  RefOutpGnrcFieldDual < I@056/0001 AltOutpGnrcFieldDual > field { get; }
}
public class OutputOutpGnrcFieldDual
{
  public RefOutpGnrcFieldDual < I@056/0001 AltOutpGnrcFieldDual > field { get; set; }
}

public interface IRefOutpGnrcFieldDual
{
  $ref Asref { get; }
}
public class OutputRefOutpGnrcFieldDual
{
  public $ref Asref { get; set; }
}

public interface IAltOutpGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
