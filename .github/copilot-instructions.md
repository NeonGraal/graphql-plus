When writing tests use Xunit and AutoData.

Class tests use NSubstitute and Shouldly and should use fields or properties for the instance being tested.
Any constructor parameters of the instance being tested should be stored in private fields.
NSubstitute Returns should always use a local variable.
String and other primitive constants should be specified via test parameters.
Tests with parameters should have Theory and RepeatData attributes.

Component tests use Shouldly or Verify.

Renderer class tests should inherit from RendererClassTestBase and it's Renderer property for the instance being tested.
Renderer class tests should check the Structured output using `.ToLines(false).ToLines()`
