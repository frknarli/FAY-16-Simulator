# FAY-16-Simulator

FAY-16-Simulator is a Windows Forms application that simulates a 16-bit FAY processor architecture. It provides a visual interface for executing and debugging assembly code while monitoring registers, instruction memory, and data memory in real-time.


![IDE](https://github.com/user-attachments/assets/f354159c-7fcd-47c4-916f-d852b9d15594)

## Features

- Rich text editor with line numbers for assembly code input
- Real-time register value monitoring
- Instruction memory visualization
- Data memory visualization
- Step-by-step execution
- Support for multiple number formats (Decimal, Binary, Hexadecimal)
- Visual processor state tracking (PC, LO, HI registers)

## Supported Instructions

### R-Type Instructions
- ADD - Addition
- SUB - Subtraction
- OR - Logical OR
- XOR - Logical XOR
- AND - Logical AND
- MUL - Multiplication
- JR - Jump Register
- SLT - Set Less Than

### I-Type Instructions
- LW - Load Word
- SW - Store Word
- BEQ - Branch if Equal
- BNE - Branch if Not Equal
- ADDI - Add Immediate
- ANDI - AND Immediate
- MULI - Multiply Immediate
- SRL - Shift Right Logical
- SLL - Shift Left Logical
- LUI - Load Upper Immediate
- SLTI - Set Less Than Immediate
- MFLO - Move From LO
- MFHI - Move From HI

### J-Type Instructions
- J - Jump
- JAL - Jump and Link

## System Requirements

- Windows Operating System
- .NET Framework 4.8
- Visual Studio 2017 or later (for development)

## Development Setup

1. Clone the repository
2. Open `CORG-16-Simulator.sln` in Visual Studio
3. Build the solution
4. Run the application

## Project Structure

- `/Hardware` - Core processor components (Registers, Memory, etc.)
- `/InstructionFields` - Instruction encoding definitions
- `/Properties` - Project properties and settings
- `Form1.cs` - Main application window
- `Executer.cs` - Instruction execution logic
- `LineNumberRTB.cs` - Custom rich text box with line numbers

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## Acknowledgments

- Built for Computer Organization course projects
- Inspired by MIPS architecture
