import os
import sys
import subprocess

print("Writing CareBridge Copyright Documentation Builder...")

# We will write out Content1.cs, Content2.cs, Program.cs in pdf_builder/
os.makedirs("pdf_builder", exist_ok=True)
