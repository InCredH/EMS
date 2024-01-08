import fpdf
from supabase import create_client, Client
from datetime import datetime
now = datetime.now()
 
# Connect to Supabase
supabase_url = 'https://ancbnkbfgrtsqxeseeqh.supabase.co'
supabase_key = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFuY2Jua2JmZ3J0c3F4ZXNlZXFoIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTkxMDc4ODEsImV4cCI6MjAxNDY4Mzg4MX0.Z9avEqN7KmcmwK3zwgTTX1rFc7OSwZh2aZsEWNZ5xFk'
client = create_client(supabase_url, supabase_key)

# Use the execute_sql method to run a custom SQL query
data = client.table('report').select("*").execute()


pdf = fpdf.FPDF()
pdf.add_page()
pdf.set_font('Arial', size=12)

# Add header
pdf.cell(200, 10, txt='Daily Report', ln=1, align='C')
pdf.cell(200, 10, txt='Generated on: ' + str(now), ln=1, align='C') 
pdf.cell(200, 10, '', ln=1)  # Add a blank line

# Add table header
pdf.cell(35, 10, txt='Historian ID', border=1)
pdf.cell(35, 10, txt='Min', border=1)
pdf.cell(35, 10, txt='Max', border=1)
pdf.cell(35, 10, txt='Avg', border=1)
pdf.cell(35, 10, txt='Count', border=1)
pdf.ln()  # Move to next line

# Add table data
for row in data:
    if(row[1] is not None):
        for d in row[1]:
            # print(d['historianid']) 
            pdf.cell(35, 10, txt=str(d['historianid']), border=1)
            pdf.cell(35, 10, txt=str(d['min']), border=1)
            pdf.cell(35, 10, txt=str(d['max']), border=1)
            pdf.cell(35, 10, txt=str(d['avg']), border=1)
            pdf.cell(35, 10, txt=str(d['count']), border=1) 
            pdf.ln()  # Move to next line

# Save the PDF
pdf.output('report.pdf', 'F')